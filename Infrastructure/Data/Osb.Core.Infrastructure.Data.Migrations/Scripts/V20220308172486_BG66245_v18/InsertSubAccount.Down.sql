DROP FUNCTION public.insertsubaccount(bigint, character varying, character varying, character varying, character varying, bigint);

CREATE OR REPLACE FUNCTION public.insertsubaccount(
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramUserId" bigint)
    RETURNS TABLE("SubAccountId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."SubAccount"(
					"Bank",
					"BankBranch",
					"BankAccount",
					"BankAccountDigit",
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId")
			VALUES (
					"paramBank",
					"paramBankBranch",
					"paramBankAccount",
					"paramBankAccountDigit",
					Now(),
					Now(),
					"paramUserId",
					"paramUserId") RETURNING "SubAccountId";
$BODY$;

ALTER FUNCTION public.insertsubaccount(character varying, character varying, character varying, character varying, bigint)
    OWNER TO "OSB";
