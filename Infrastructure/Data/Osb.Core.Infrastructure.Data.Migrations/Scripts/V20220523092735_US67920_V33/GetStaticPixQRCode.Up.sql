CREATE OR REPLACE FUNCTION public.getstaticpixqrcode(
	"paramPixKeyType" integer,
	"paramUserId" bigint,
	"paramAccountId" bigint
    )
    RETURNS TABLE( 
        "StaticPixQRCodeId" bigint,
        "UserId" bigint,
        "AccountId" bigint,
        "ExternalIdentifier" bigint,
        "QRCode" character varying,
        "HashCode" character varying,
        "PixKeyType" integer,
        "CreationDate" timestamp without time zone,
        "UpdateDate" timestamp without time zone,
        "DeletionDate" timestamp without time zone,
        "CreationUserId" bigint,
        "UpdateUserId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT  "StaticPixQRCodeId",
        "UserId",
        "AccountId",
        "ExternalIdentifier",
        "QRCode",
        "HashCode",
        "PixKeyType",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."StaticPixQRCode"
WHERE "PixKeyType" = "paramPixKeyType"
    AND "UserId" = "paramUserId"
    AND "AccountId" = "paramAccountId"
    AND "DeletionDate" IS NULL

$BODY$;
ALTER FUNCTION public.getstaticpixqrcode(integer, bigint, bigint)
    OWNER TO "OSB";