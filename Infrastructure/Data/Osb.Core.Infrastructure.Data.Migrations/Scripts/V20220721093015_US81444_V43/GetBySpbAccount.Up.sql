CREATE OR REPLACE FUNCTION public.getbyspbaccount(
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying)
    RETURNS TABLE("SPBAccountId" bigint, accountid bigint, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
	"SPBAccountId",
	"AccountId",
	"Bank",
	"BankBranch",
	"BankAccount",
	"BankAccountDigit",
	"CreationDate",
	"UpdateDate", 
	"DeletionDate",
	"CreationUserId", 
	"UpdateUserId" 
	FROM public."SPBAccount"
	Where
	"Bank" = "paramBank"
	AND "BankBranch" = "paramBankBranch"
	AND "BankAccount" = "paramBankAccount"
	AND "BankAccountDigit" = "paramBankAccountDigit"
	AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getbyspbaccount(character varying, character varying, character varying, character varying)
    OWNER TO "OSB";