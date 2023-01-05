CREATE OR REPLACE FUNCTION public.getpixkeylistbystatus(
	"paramStatus" bigint)
    RETURNS TABLE("PixKeyId" bigint, "AccountId" bigint, "UserId" bigint, "PixKeyValue" character varying, "PixKeyType" character varying, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
    PK."PixKeyId",
    PK."AccountId",
    PK."UserId",
    PK."PixKeyValue",
    PK."PixKeyType",
    PK."Status",
    PK."CreationDate",
    PK."UpdateDate",
    PK."CreationUserId",
    PK."UpdateUserId"
    FROM public."PixKey" AS PK
    WHERE 
    PK."Status" = "paramStatus"
    AND PK."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getpixkeylistbystatus(bigint)
    OWNER TO "OSB";