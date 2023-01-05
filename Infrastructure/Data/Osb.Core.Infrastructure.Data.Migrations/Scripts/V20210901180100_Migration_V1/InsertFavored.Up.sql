CREATE OR REPLACE FUNCTION public.insertfavored(
	"paramAccountId" bigint,
	"paramTaxId" character varying,
	"paramName" character varying,
	"paramOperationType" integer,
	"paramBankName" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Favored"
                    (
					 "AccountId",
					 "TaxId",
					 "Name",
				     "OperationType",
					 "BankName",
					 "Bank",
					 "BankBranch",
					 "BankAccount",
					 "BankAccountDigit",
					 "CreationDate",
					 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId"
					 )
				VALUES 
					(
					"paramAccountId",
					"paramTaxId",
					"paramName",
					"paramOperationType",
					"paramBankName",
					"paramBank",
					"paramBankBranch",
					"paramBankAccount",
					"paramBankAccountDigit",
					now(),
					now(),
					"paramUserId",
					"paramUserId"
					)
$BODY$;

ALTER FUNCTION public.insertfavored(bigint, character varying, character varying, integer, character varying,character varying, character varying, character varying, character varying,bigint)
    OWNER TO "OSB";
