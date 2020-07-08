CREATE PROCEDURE TAO_BCTONKHO
@Thang INT,
@Nam INT,
@MaSanPham INT,
@TonDau INT,
@TonCuoi INT,
@SLMuaVao INT,
@SLBanRa INT
AS
BEGIN
	DECLARE @i INT = 0, @count INT
	SELECT @count = COUNT(*)
	FROM SANPHAM 
	WHILE @i < @count
	BEGIN 
		SELECT @MaSanPham = MaSP FROM SANPHAM 
		ORDER BY MaSP
		OFFSET @i ROWS
		FETCH NEXT 1 ROWS ONLY 
		BEGIN
			SELECT @SLBanRa = COALESCE(SUM(SoLuong),0)
			FROM PHIEUBANHANG, CT_PHIEUBANHANG
			WHERE PHIEUBANHANG.MaPBH = CT_PHIEUBANHANG.MaPBH AND MONTH(PHIEUBANHANG.NgayLap) = @Thang 
			AND YEAR(PHIEUBANHANG.NgayLap) = @Nam AND @MaSanPham = CT_PHIEUBANHANG.MaSP
		END 

		BEGIN
			SELECT @SLMuaVao = COALESCE(SUM(SoLuong),0)
			FROM PHIEUMUAHANG, CHITIET_PMH
			WHERE PHIEUMUAHANG.MaPMH = CHITIET_PMH.MaPMH AND MONTH(PHIEUMUAHANG.NgayLap) = @Thang 
			AND YEAR(PHIEUMUAHANG.NgayLap) = @Nam AND @MaSanPham = CHITIET_PMH.MaSP
		END 

		BEGIN
			IF (@Thang = 1)
			BEGIN
				SELECT @TonDau = TonCuoi
				FROM BCTONKHO
				WHERE Thang = 12 AND Nam = @Nam - 1 AND MaSP = @MaSanPham
			END
			ELSE 
			BEGIN
				SELECT @TonDau = TonCuoi
				FROM BCTONKHO
				WHERE Thang = @Thang - 1 AND Nam = @Nam AND MaSP = @MaSanPham
			END
		END

		SET @TonCuoi = @TonDau + @SLMuaVao - @SLBanRa

		INSERT INTO BCTONKHO(Thang,Nam, MaSP, Tondau, TonCuoi, SLMuaVao, SLBanRa) 
		VALUES (@Thang,@Nam, @MaSanPham, @TonDau, @TonCuoi, @SLMuaVao, @SLBanRa)

	SET @i = @i + 1;
	END
END


