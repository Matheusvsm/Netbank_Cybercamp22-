CREATE OR REPLACE FUNCTION public.updategarepayment(
	"paramGAREPaymentId" bigint,
	"paramExternalIdentifier" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUpdateUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."GAREPayment"
			  SET
                "Status" = "paramStatus",
				"Attempts" = "paramAttempts",
				"ExternalIdentifier" = "paramExternalIdentifier",
				"UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()
		 	  WHERE 
	            "GAREPaymentId" = "paramGAREPaymentId"
$BODY$;

ALTER FUNCTION public.updategarepayment(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";
