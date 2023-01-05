CREATE OR REPLACE FUNCTION public.getpendinginternaltransferlistbystatus(
	"paramStatus" integer)
    RETURNS TABLE("PendingInternalTransferId" bigint, "AccountId" bigint, "PhoneNumber" character varying, "CountryCode" character varying, "Value" numeric, "Identifier" character varying, "FromTaxId" character varying, "FromBank" character varying, "FromBankBranch" character varying, "FromBankAccount" character varying, "FromBankAccountDigit" character varying, "Status" integer, "Attempts" integer, "DeletionDate" timestamp without time zone, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "PendingInternalTransferId",
        "AccountId",
        "PhoneNumber",
        "CountryCode",
        "Value",
        "Identifier",
        "FromTaxId",
        "FromBank",
        "FromBankBranch",
        "FromBankAccount",
        "FromBankAccountDigit",
        "Status",
        "Attempts",
        "DeletionDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM public."PendingInternalTransfer"
    WHERE "Status"="paramStatus"
    AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getpendinginternaltransferlistbystatus(integer)
    OWNER TO "OSB";
