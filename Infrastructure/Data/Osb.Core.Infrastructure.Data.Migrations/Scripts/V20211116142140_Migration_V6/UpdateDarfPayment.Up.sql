CREATE OR REPLACE FUNCTION public.updatedarfpayment(
    "paramDARFPaymentId" bigint,
    "paramExternalIdentifier" bigint,
    "paramStatus" integer,
    "paramAttempts" integer,
    "paramUpdateUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."DARFPayment"
        SET
            "Status" = "paramStatus",
            "ExternalIdentifier" = "paramExternalIdentifier",
            "UpdateDate" = now(),
            "Attempts" = "paramAttempts",
            "UpdateUserId" = "paramUpdateUserId"
        WHERE
            "DeletionDate" IS NULL AND
            "DARFPaymentId" = "paramDARFPaymentId"
$BODY$;
ALTER FUNCTION public.updatedarfpayment(bigint, bigint, integer, integer, bigint)
    OWNER TO "OSB";
