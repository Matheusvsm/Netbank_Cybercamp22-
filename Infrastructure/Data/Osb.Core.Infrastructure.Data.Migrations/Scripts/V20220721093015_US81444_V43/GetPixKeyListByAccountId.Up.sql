CREATE OR REPLACE FUNCTION public.getpixkeylistbyaccountid(
    "paramAccountId" bigint
)
RETURNS TABLE(
    "PixKeyId" bigint ,  
    "AccountId" bigint,
    "UserId" bigint,
    "PixKeyValue" character varying,
    "PixKeyType" character varying,
    "CreationDate" timestamp without time zone,
    "UpdateDate" timestamp without time zone,
    "CreationUserId" bigint,
    "UpdateUserId" bigint
)
LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT 
    "PixKeyId",
    "AccountId",
    "UserId",
    "PixKeyValue",
    "PixKeyType",
    "CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
FROM public."PixKey"
WHERE 
    "AccountId" = "paramAccountId" 
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getpixkeylistbyaccountid(bigint)
    OWNER TO "OSB";