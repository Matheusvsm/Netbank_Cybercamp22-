CREATE OR REPLACE FUNCTION public.updatedarjpayment(
	"paramDARJPaymentId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."DARJPayment"
		SET	  	
		   "ExternalIdentifier" = "paramExternalIdentifier",
		   "Status" = "paramStatus",
		   "Attempts" = "paramAttempts",
		   "UpdateDate" = Now(),
		   "UpdateUserId" = "paramUpdateUserId"
		WHERE 
		   "DARJPaymentId" = "paramDARJPaymentId"
$BODY$;

ALTER FUNCTION public.updatedarjpayment(bigint, bigint, integer, integer, bigint)
     OWNER TO "OSB";
