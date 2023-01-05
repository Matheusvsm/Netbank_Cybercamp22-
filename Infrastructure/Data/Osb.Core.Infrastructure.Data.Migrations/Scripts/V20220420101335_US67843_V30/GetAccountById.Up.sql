DROP FUNCTION public.getaccountbyid(bigint);

CREATE FUNCTION public.getaccountbyid(
	"paramId" bigint)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "TaxId" character varying, "AccountKey" character varying, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "SPBBank" character varying, "SPBBankBranch" character varying, "SPBBankAccount" character varying, "SPBBankAccountDigit" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  ACC."AccountId",
        ACC."CompanyId",
        ACC."Name",
        ACC."Type",
        ACC."Status",
        ACC."CreationDate",
        ACC."UpdateDate",
        ACC."DeletionDate",
        ACC."CreationUserId",
        ACC."UpdateUserId",
        ACC."TaxId",
        ACC."AccountKey",
        SACC."Bank",
        SACC."BankBranch",
        SACC."BankAccount",
        SACC."BankAccountDigit",
		SPB."Bank" AS "SPBBank",
        SPB."BankBranch" AS "SPBBankBranch",
        SPB."BankAccount" AS "SPBBankAccount",
        SPB."BankAccountDigit" AS "SPBBankAccountDigit"
    FROM
        public."Account" AS ACC
        LEFT JOIN public."SubAccount" AS SACC ON (SACC."AccountId" = ACC."AccountId")
		LEFT JOIN public."SPBAccount" AS SPB ON (SPB."AccountId" = ACC."AccountId")
    WHERE
        (ACC."AccountId" = "paramId")
        AND ACC."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbyid(bigint)
    OWNER TO "OSB";
