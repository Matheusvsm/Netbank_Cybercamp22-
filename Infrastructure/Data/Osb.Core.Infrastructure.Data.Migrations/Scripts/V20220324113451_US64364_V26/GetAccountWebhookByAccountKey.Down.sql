CREATE OR REPLACE FUNCTION public.getaccountwebhookbyaccountkey(
	"paramAccountKey" character varying
    )
    RETURNS TABLE(
        "AccountWebhookId" bigint,
        "AccountConditionType" integer,
        "AccountStatus" bigint,
        "AccountKey" character varying,
        "AccountCreationDate" timestamp without time zone,
        "AccountConditionId" bigint,
        "CompanyAuthenticationId" bigint,
        "CompanyId" bigint,
        "Identifier" bigint,
        "TaxId" character varying,
        "FromBank" character varying,
        "FromBankBranch" character varying,
        "FromBankAccount" character varying,
        "FromBankAccountDigit" character varying,
        "SendDate" timestamp without time zone,
        "ToBank" character varying,
        "ToBankBranch" character varying,
        "ToBankAccount" character varying,
        "ToBankAccountDigit" character varying,
        "Method" character varying,
        "Status" integer,
        "CreationDate" timestamp without time zone,
        "UpdateDate" timestamp without time zone,
        "DeletionDate" timestamp without time zone,
        "CreationUserId" bigint,
        "UpdateUserId" bigint
        )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT  "AccountWebhookId",
        "AccountConditionType",
        "AccountStatus",
        "AccountKey",
        "AccountCreationDate",
        "AccountConditionId",
        "CompanyAuthenticationId",
        "CompanyId",
        "Identifier",
        "TaxId",
        "FromBank",
        "FromBankBranch",
        "FromBankAccount",
        "FromBankAccountDigit",
        "SendDate",
        "ToBank",
        "ToBankBranch",
        "ToBankAccount",
        "ToBankAccountDigit",
        "Method",
        "Status",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."AccountWebhook"
WHERE "AccountKey" = "paramAccountKey"
    AND "DeletionDate" IS NULL

$BODY$;
ALTER FUNCTION public.getaccountwebhookbyaccountkey(character varying)
    OWNER TO "OSB";