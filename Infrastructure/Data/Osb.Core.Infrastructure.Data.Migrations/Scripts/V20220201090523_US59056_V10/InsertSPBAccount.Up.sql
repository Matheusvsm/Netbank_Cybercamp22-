CREATE OR REPLACE FUNCTION public.insertspbaccount(
	"paramAccountId" bigint,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramUserId" bigint
	)
    RETURNS TABLE("SPBAccountId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."SPBAccount"(
					"AccountId",
					"Bank",
					"BankBranch",
					"BankAccount",
					"BankAccountDigit",
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId"
					)
			VALUES (
					"paramAccountId",
					"paramBank",
					"paramBankBranch",
					"paramBankAccount",
					"paramBankAccountDigit",
					Now(),
					Now(),
					"paramUserId",
					"paramUserId") RETURNING "SPBAccountId";
$BODY$;

ALTER FUNCTION public.insertspbaccount(bigint, character varying, character varying, character varying, character varying, bigint)
    OWNER TO "OSB";
