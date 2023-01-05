CREATE OR REPLACE FUNCTION public.getpixkeybypixkeyid(
    "paramPixKeyId" bigint
)
RETURNS TABLE(

    "PixKeyValue" character varying,
    "PixKeyType" character varying
    
)
LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT 
    "PixKeyValue",
    "PixKeyType"

FROM public."PixKey"
WHERE 
    "PixKeyId" = "paramPixKeyId"
    AND "DeletionDate" IS NULL;

$BODY$;
ALTER FUNCTION public.getpixkeybypixkeyid(bigint)
    OWNER TO "OSB";