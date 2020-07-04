var table = $('#tra_cuu_dich_vu').DataTable();
 
$('#so_phieu').on( 'keyup', function () {
    table
        .columns( 0 )
        .search( this.value )
        .draw();
} );

// $('#ngay_lap').on( 'keyup', function () {
//     var _self = this;
//     var date_search;
//     if ( _self.value.valueOf() ) {
//         var vals = _self.value.split('-');
//         date_search = vals[2] + "/" + vals[1] + "/" + vals[0];
//     };
//     table
//         .columns( 1 )
//         .search( date_search )
//         .draw();
// } );

// $('#ngay_lap').on( 'mouseup', function () {
//     var _self = this;
//     var date_search;
//     if ( _self.value.valueOf() ) {
//         var vals = _self.value.split('-');
//         date_search = vals[2] + "/" + vals[1] + "/" + vals[0];
//     };
//     table
//         .columns( 1 )
//         .search( date_search )
//         .draw();
// } );
$('#ngay_lap').on( 'keyup', function () {
    table
        .columns( 1 )
        .search( this.value )
        .draw();
} );

$('#khach_hang').on( 'keyup', function () {
    table
        .columns( 2 )
        .search( this.value )
        .draw();
} );

$('#tong_tien').on( 'keyup', function () {
    table
        .columns( 3 )
        .search( this.value )
        .draw();
} );

$('#tra_truoc').on( 'keyup', function () {
    table
        .columns( 4 )
        .search( this.value )
        .draw();
} );

$('#con_lai').on( 'keyup', function () {
    table
        .columns( 5 )
        .search( this.value )
        .draw();
} );

$('#tinh_trang').on( 'mouseup', function () {
    var _self = this;;
    if (_self.value != "--- Chọn ---") {
        table
            .columns( 6 )
            .search( this.value )
            .draw();
    }
} );

(function( $ ) {

	'use strict';

	var EditableTable = {

		options: {
			addButton: '#addToTable',
			table: '#sanpham',
			dialog: {
				wrapper: '#dialog',
				cancelButton: '#dialogCancel',
				confirmButton: '#dialogConfirm',
			}
		},

		initialize: function() {
			this
				.setVars()
				.build()
				.events();
		},

		setVars: function() {
			this.$table				= $( this.options.table );
			this.$addButton			= $( this.options.addButton );

			// dialog
			this.dialog				= {};
			this.dialog.$wrapper	= $( this.options.dialog.wrapper );
			this.dialog.$cancel		= $( this.options.dialog.cancelButton );
			this.dialog.$confirm	= $( this.options.dialog.confirmButton );

			return this;
		},

		build: function() {
			this.datatable = this.$table.DataTable({
				aoColumns: [
					null,
					null,
					null,
                    null,
                    null,
                    null,
                    null,
					{ "bSortable": false }
				]
			});

			window.dt = this.datatable;

			return this;
		},

		events: function() {
			var _self = this;

			this.$table
				.on('click', 'a.save-row', function( e ) {
					e.preventDefault();

					_self.rowSave( $(this).closest( 'tr' ) );
				})
				.on('click', 'a.cancel-row', function( e ) {
					e.preventDefault();

					_self.rowCancel( $(this).closest( 'tr' ) );
				})
				.on('click', 'a.edit-row', function( e ) {
					e.preventDefault();

					_self.rowEdit( $(this).closest( 'tr' ) );
				})
				.on( 'click', 'a.remove-row', function( e ) {
					e.preventDefault();

					var $row = $(this).closest( 'tr' );

					$.magnificPopup.open({
						items: {
							src: '#dialog',
							type: 'inline'
						},
						preloader: false,
						modal: true,
						callbacks: {
							change: function() {
								_self.dialog.$confirm.on( 'click', function( e ) {
									e.preventDefault();

									_self.rowRemove( $row );
									$.magnificPopup.close();
								});
							},
							close: function() {
								_self.dialog.$confirm.off( 'click' );
							}
						}
					});
				});

			this.$addButton.on( 'click', function(e) {
				e.preventDefault();

				_self.rowAdd();
			});

			this.dialog.$cancel.on( 'click', function( e ) {
				e.preventDefault();
				$.magnificPopup.close();
			});

			return this;
		},

		// ==========================================================================================
		// ROW FUNCTIONS
		// ==========================================================================================
		rowAdd: function() {            
			this.$addButton.attr({ 'disabled': 'disabled' });

			var actions,
				data,
				$row,
                ma = $("#ma").val(),
                ten = $("#ten").val(),
                loai = $("loai option:selected").val(),
                donvitinh = $("#donvitinh").val(),
                giamua = $("#giamua").val(),
                giaban = $("#giaban").val(),
                soluongton = $("#soluongton").val(),
                check = true;

			actions = [
				'<a href="#" class="hidden on-editing save-row"><i class="fa fa-save" style="font-size:20px"></i></a>',
				'<a href="#" class="hidden on-editing cancel-row"><i class="fa fa-times" style="font-size:20px"></i></a>',
				'<a href="#" class="on-default edit-row"><i class="fa fa-pencil-alt"></i></a>',
				'<a href="#" class="on-default remove-row"><i class="fa fa-trash-alt"></i></a>'
			].join(' ');
            
			data = this.datatable.row.add([ ma, ten, loai, donvitinh, giamua, giaban, soluongton, actions ]);
            
            $row = this.datatable.row( data[0] ).nodes().to$();
                
			$row
				.addClass( 'adding' )
				.find( 'td:last' )
				.addClass( 'actions' );
            
			this.$addButton.removeAttr( 'disabled' );
            $row.removeClass( 'adding' );

			this.datatable.order([0,'asc']).draw(); // always show field
            
            $('#ma').val(parseInt($('#sanpham tr:last td:first').text()) + 1);
            $("#ten").val('');
            $("loai").val('--- Chọn ---');
            $("#donvitinh").val('');
            $("#giamua").val('');
            $("#giaban").val('');
            $("#soluongton").val('');
		},

		rowCancel: function( $row ) {
			var _self = this,
				$actions,
				i,
				data;

			if ( $row.hasClass('adding') ) {
				this.rowRemove( $row );
			} else {

				data = this.datatable.row( $row.get(0) ).data();
				this.datatable.row( $row.get(0) ).data( data );

				$actions = $row.find('td.actions');
				if ( $actions.get(0) ) {
					this.rowSetActionsDefault( $row );
				}

				this.datatable.draw();
			}
		},

		rowEdit: function( $row ) {
			var _self = this,
				data;

			data = this.datatable.row( $row.get(0) ).data();

			$row.children( 'td' ).each(function( i ) {
				var $this = $( this );
				switch(i) {
                    case 0:
                        $this.html( '<input type="number" class="form-control input-block" readonly value="' + data[i] + '"/>' );
                        break;
                    case 1:
                        $this.html( '<input type="text" class="form-control input-block" value="' + data[i] + '"/>' );
                        break;
                    case 3:
                        $this.html( '<input type="text" class="form-control input-block" readonly value="' + data[i] + '"/>' );
                        break;
                    case 4:
                    case 5:
                    case 6:
                        $this.html( '<input type="number" class="form-control input-block" value="' + data[i] + '"/>' );
                        break;
                    case 7:
                        _self.rowSetActionsEditing( $row );
                        break;
                    }
				}
			);
		},

		rowSave: function( $row ) {
			var _self     = this,
				$actions,
				values    = [];

			if ( $row.hasClass( 'adding' ) ) {
				this.$addButton.removeAttr( 'disabled' );
				$row.removeClass( 'adding' );
			}

			values = $row.find('td').map(function() {
				var $this = $(this);

				if ( $this.hasClass('actions') ) {
					_self.rowSetActionsDefault( $row );
					return _self.datatable.cell( this ).data();
				} else {
					return $.trim( $this.find('input').val() );
				}
			});

			this.datatable.row( $row.get(0) ).data( values );

			$actions = $row.find('td.actions');
			if ( $actions.get(0) ) {
				this.rowSetActionsDefault( $row );
			}

			this.datatable.draw();
		},

		rowRemove: function( $row ) {
			if ( $row.hasClass('adding') ) {
				this.$addButton.removeAttr( 'disabled' );
			}

			this.datatable.row( $row.get(0) ).remove().draw();
		},

		rowSetActionsEditing: function( $row ) {
			$row.find( '.on-editing' ).removeClass( 'hidden' );
			$row.find( '.on-default' ).addClass( 'hidden' );
		},

		rowSetActionsDefault: function( $row ) {
			$row.find( '.on-editing' ).addClass( 'hidden' );
			$row.find( '.on-default' ).removeClass( 'hidden' );
		}

	};

	$(function() {
		EditableTable.initialize();
	});

}).apply( this, [ jQuery ]);