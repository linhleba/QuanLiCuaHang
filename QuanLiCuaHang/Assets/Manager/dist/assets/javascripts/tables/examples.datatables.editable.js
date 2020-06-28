﻿$("#success-alert").hide();
$("#danger-alert").hide();
$(function(){
    $("[data-hide]").on("click", function(){
        $(this).closest("." + $(this).attr("data-hide")).hide();
    });
});
$('#ma').val(parseInt($('#datatable-editable tr:last td:first').text()) + 1);

(function( $ ) {

	'use strict';

	var EditableTable = {

		options: {
			addButton: '#addToTable',
			table: '#datatable-editable',
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
                phantramloinhuan = $("#phantramloinhuan").val(),
                donvitinh = $("#donvitinh option:selected").val(),
                check = true;

			actions = [
				'<a href="#" class="hidden on-editing save-row"><i class="fa fa-save" style="font-size:20px"></i></a>',
				'<a href="#" class="hidden on-editing cancel-row"><i class="fa fa-times" style="font-size:20px"></i></a>',
				'<a href="#" class="on-default edit-row"><i class="fa fa-pencil-alt"></i></a>',
				'<a href="#" class="on-default remove-row"><i class="fa fa-trash-alt"></i></a>'
			].join(' ');
            
            let menu = document.getElementById('danger-alert');
            
            if (!ten)
            {
                let p = document.createElement('p');
                p.textContent = "Tên loại sản phẩm đ*o được để trống. Vui lòng nhập thông tin cho tên loại sản phẩm.";
                menu.appendChild(p);
                check = false;
            }
            
            if (!phantramloinhuan)
            {
                let p = document.createElement('p');
                p.textContent = "Phần trăm lợi nhuận đ*o được để trống. Vui lòng nhập thông tin cho phần trăm lợi nhuận.";
                menu.appendChild(p);
                check = false;
            }
            
            if (donvitinh == "--- Chọn ---")
            {
                let p = document.createElement('p');
                p.textContent = "Đơn vị tính đ*o được để trống. Vui lòng nhập thông tin cho đơn vị tính.";
                menu.appendChild(p);
                check = false;
            }
            
            if (check == false)
            {
                this.$addButton.removeAttr( 'disabled' );
                $("#danger-alert").show();
                return;
            }
            
			data = this.datatable.row.add([ ma, ten, phantramloinhuan, donvitinh, actions ]);
            
            $row = this.datatable.row( data[0] ).nodes().to$();
                
			$row
				.addClass( 'adding' )
				.find( 'td:last' )
				.addClass( 'actions' );
            
			this.$addButton.removeAttr( 'disabled' );
            $row.removeClass( 'adding' );

			this.datatable.order([0,'asc']).draw(); // always show field
            
            $("#success-alert").show();
            
            $('#ma').val(parseInt($('#datatable-editable tr:last td:first').text()) + 1);
            $('#ten').val('');
            $('#phantramloinhuan').val('');
            $('#donvitinh').val('cây');
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
                    case 2:
                        $this.html( '<input type="number" class="form-control input-block" value="' + data[i] + '"/>' );
                        break;
                    case 3:
                        $this.html( '<select class="form-control input-block"> value="' + data[i] + '"> <option>--- Chọn ---</option> <option>cây</option> <option>người</option> <option>viên</option> </select>'  );
                        break;
                    case 4:
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