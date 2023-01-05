CREATE OR REPLACE FUNCTION public.getbyspbaccountandtaxId(
	"paramTaxId" character varying,
	"paramSpbBank" character varying, 
	"paramSpbBankBranch" character varying, 
	"paramSpbBankAccount" character varying, 
	"paramSpbBankAccountDigit" character varying)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "TaxId" character varying, "AccountKey" character varying, "SPBBank" character varying, "SPBBankBranch" character varying, "SPBBankAccount" character varying, "SPBBankAccountDigit" character varying) 
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
		SPB."Bank" AS "SPBBank",
        SPB."BankBranch" AS "SPBBankBranch",
        SPB."BankAccount" AS "SPBBankAccount",
        SPB."BankAccountDigit" AS "SPBBankAccountDigit"
    FROM
        public."Account" AS ACC
		LEFT JOIN public."SPBAccount" AS SPB ON (SPB."Bank" = "paramSpbBank" 
												 AND SPB."BankBranch" = "paramSpbBankBranch"
												 AND SPB."BankAccount" = "paramSpbBankAccount"
												 AND SPB."BankAccountDigit" = "paramSpbBankAccountDigit") 
	WHERE
		ACC."TaxId" = "paramTaxId"
		AND ACC."DeletionDate" IS NULL;														 
$BODY$;

ALTER FUNCTION public.getbyspbaccountandtaxId(character varying,character varying,character varying,character varying,character varying)
    OWNER TO "OSB";
