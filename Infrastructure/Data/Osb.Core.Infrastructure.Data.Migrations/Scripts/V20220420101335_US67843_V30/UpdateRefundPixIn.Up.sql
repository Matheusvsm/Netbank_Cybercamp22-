CREATE OR REPLACE FUNCTION public.updaterefundpixin(
	"paramRefundPixInId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."RefundPixIn"
    SET
        "Status" = "paramStatus",
        "ExternalIdentifier" = "paramExternalIdentifier",
        "UpdateDate" = Now(),
		"Attempts" = "paramAttempts",
        "UpdateUserId" = "paramUpdateUserId"
    WHERE
        "RefundPixInId" = "paramRefundPixInId"
$BODY$;

ALTER FUNCTION public.updaterefundpixin(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";