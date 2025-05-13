use QuanLy_Kho
go

CREATE PROC uspAddProduct
	@BARCODE nvarchar(13),
	@TENHH nvarchar(50),
	@TENTAT nvarchar(50), 
	@DVT nvarchar(50), 
	@DONGIA decimal(18,0), 
	@MANCC int, 
	@MAXX int, 
	@IDNHOM nvarchar(50), 
	@MOTA nvarchar(500), 
	@CREATED_DATE datetime, 
	@CREATED_BY int, 
	@DISABLED bit,
	@pImage image = NULL

AS
BEGIN
    INSERT INTO tb_HANGHOA (
        BARCODE, TENHH, TENTAT, DVT, DONGIA, MANCC, MAXX, IDNHOM, MOTA,
        CREATED_DATE, CREATED_BY, DISABLED, pImage
    )
    VALUES (
        @BARCODE, @TENHH, @TENTAT, @DVT, @DONGIA, @MANCC, @MAXX, @IDNHOM, @MOTA,
        @CREATED_DATE, @CREATED_BY, @DISABLED, @pImage
    )
END
GO

CREATE PROC uspUpdateProduct
	@BARCODE nvarchar(13),
	@TENHH nvarchar(50),
	@TENTAT nvarchar(50), 
	@DVT nvarchar(50), 
	@DONGIA decimal(18,0), 
	@MANCC int, 
	@MAXX int, 
	@IDNHOM nvarchar(50), 
	@MOTA nvarchar(500), 
	@CREATED_DATE datetime, 
	@CREATED_BY int, 
	@DISABLED bit,
	@pImage image = null
AS
BEGIN
    UPDATE tb_HANGHOA
	SET TENHH = @TENHH,
		TENTAT = @TENTAT,
		DVT = @DVT,
		DONGIA = @DONGIA,
		MANCC = @MANCC,
		MAXX = @MAXX,
		IDNHOM = @IDNHOM,
		MOTA = @MOTA,
		CREATED_DATE = @CREATED_DATE,
		CREATED_BY = @CREATED_BY,
		DISABLED = @DISABLED,
		pImage = @pImage
	WHERE BARCODE = @BARCODE
END
GO

CREATE PROC uspDeleteProduct
	@BARCODE nvarchar(13)

AS
BEGIN
    DELETE FROM tb_HANGHOA WHERE BARCODE = @BARCODE
END
GO