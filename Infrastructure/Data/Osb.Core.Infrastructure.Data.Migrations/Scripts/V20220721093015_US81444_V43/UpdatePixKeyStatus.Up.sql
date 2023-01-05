CREATE OR REPLACE FUNCTION public.updatepixkeystatus(
    "paramPixKeyId" bigint,
    "paramPixKeyValue" varchar(50),
    "paramStatus" integer)
RETURNS void 
LANGUAGE 'sql'
COST 100
VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."PixKey"
SET
    "Status" = "paramStatus",
    "PixKeyValue" = "paramPixKeyValue",
    "UpdateDate" = Now()
WHERE
    "PixKeyId" = "paramPixKeyId"
$BODY$;

ALTER FUNCTION public.updatepixkeystatus(bigint, varchar, integer)
    OWNER TO "OSB";