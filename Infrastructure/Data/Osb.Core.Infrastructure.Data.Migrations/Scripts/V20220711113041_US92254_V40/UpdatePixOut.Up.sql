DROP FUNCTION public.updatepixout(bigint, bigint, integer, integer);

CREATE OR REPLACE FUNCTION public.updatepixout(
	"paramId" bigint,
	"paramExternalIdentifier" bigint,
    "paramResponseMessage" character varying,
	"paramStatus" integer,
	"paramAttempts" integer
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."PixOut"
    SET
        "Status" = "paramStatus",
        "ExternalIdentifier" = "paramExternalIdentifier",
        "ResponseMessage" = "paramResponseMessage",
        "UpdateDate" = now(),
		"Attempts" = "paramAttempts"
    WHERE
        "PixOutId" = "paramId"
$BODY$;

ALTER FUNCTION public.updatepixout(bigint, bigint, character varying, integer, integer)
    OWNER TO "OSB";