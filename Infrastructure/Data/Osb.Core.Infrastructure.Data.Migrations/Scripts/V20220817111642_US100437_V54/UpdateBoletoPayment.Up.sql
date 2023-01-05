DROP FUNCTION public.updateboletopayment(bigint, bigint, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.updateboletopayment(
    "paramId" bigint,
    "paramExternalIdentifier" bigint,
    "paramResponseMessage" character varying,
    "paramAttempts" integer,
    "paramStatus" integer,
    "paramUpdateUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."BoletoPayment"
    SET
        "ExternalIdentifier" = "paramExternalIdentifier",
        "Attempts" = "paramAttempts",
        "Status" = "paramStatus",
        "ResponseMessage" = "paramResponseMessage",   
        "UpdateUserId" = "paramUpdateUserId",
        "UpdateDate" = now()
    WHERE
        "BoletoPaymentId" = "paramId"
        AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updateboletopayment(bigint, bigint, character varying, integer, integer, bigint)
    OWNER TO "OSB";