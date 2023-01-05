DROP FUNCTION public.getpixKeybypixkeyvalue(integer, character varying);

CREATE OR REPLACE FUNCTION public.getpixkeybypixkeyvalue(
	"paramPixKeyType" integer,
	"paramPixKey" character varying)
    RETURNS TABLE("PixKeyId" bigint, "AccountId" bigint, "PixKeyValue" character varying, "PixKeyType" character varying, "Status" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
    PK."PixKeyId",
    PK."AccountId",    
    PK."PixKeyValue",
    PK."PixKeyType",
    PK."Status",
    PK."CreationDate",
    PK."UpdateDate",
    PK."CreationUserId",
    PK."UpdateUserId"
    FROM public."PixKey" AS PK
    WHERE 
    PK."PixKeyValue" = "paramPixKey"
    AND PK."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getpixkeybypixkeyvalue(integer, character varying)
    OWNER TO "OSB";