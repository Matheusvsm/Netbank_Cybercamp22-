CREATE FUNCTION public.updateboletopayment(
    "paramId" bigint,
    "paramExternalIdentifier" bigint,
    "paramAttempts" integer,
    "paramStatus" integer,
    "paramUpdateUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BoletoPayment"
			  SET
                "ExternalIdentifier" = "paramExternalIdentifier",
                "Attempts" = "paramAttempts",
                "Status" = "paramStatus",
                "UpdateUserId" = "paramUpdateUserId",
                "UpdateDate" = now()
		 	  WHERE
               "BoletoPaymentId" = "paramId"
               AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updateboletopayment(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";