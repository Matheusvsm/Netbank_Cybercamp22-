CREATE OR REPLACE FUNCTION public.updatepixout(
	"paramId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."PixOut"
    SET
        "Status" = "paramStatus",
        "ExternalIdentifier" = "paramExternalIdentifier",
        "UpdateDate" = Now(),
		"Attempts" = "paramAttempts"
    WHERE
        "PixOutId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatepixout(bigint, bigint, integer, integer)
    OWNER TO "OSB";