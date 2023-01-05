CREATE OR REPLACE FUNCTION public.updatefgtspayment(
	"paramFGTSPaymentId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."FGTSPayment"
    SET
        "Status" = "paramStatus",
        "ExternalIdentifier" = "paramExternalIdentifier",
        "UpdateDate" = Now(),
		"Attempts" = "paramAttempts",
        "UpdateUserId" = "paramUpdateUserId"
    WHERE
        "FGTSPaymentId" = "paramFGTSPaymentId"
$BODY$;

ALTER FUNCTION public.updatefgtspayment(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";