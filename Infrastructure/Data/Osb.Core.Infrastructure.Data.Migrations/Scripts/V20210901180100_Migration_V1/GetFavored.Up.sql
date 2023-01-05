CREATE OR REPLACE FUNCTION public.getfavored(
	"paramAccountId" bigint,
	"paramTaxId" character varying,
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
	"paramOperationType" integer
	)
    RETURNS TABLE(
		"FavoredId" bigint, 
		"AccountId" bigint, 
		"TaxId" character varying, 
		"Name" character varying, 
		"OperationType" integer, 
		"Bank" character varying, 
		"BankBranch" character varying, 
		"BankAccount" character varying, 
		"BankAccountDigit" character varying, 
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
SELECT
	   "FavoredId",
	   "AccountId",
	   "TaxId",
	   "Name",
	   "OperationType",
	   "Bank",
	   "BankBranch",
	   "BankAccount",
	   "BankAccountDigit",
	   "CreationDate",
	   "UpdateDate",
	   "DeletionDate",
	   "CreationUserId",
	   "UpdateUserId"
	   
	FROM 
		public."Favored"
	WHERE
		("AccountId" = "paramAccountId")
	AND
		("paramBank" IS NULL AND "Bank" IS NULL OR "Bank" = "paramBank" AND 
		 "paramBankBranch" IS NULL AND "BankBranch" IS NULL OR "BankBranch" = "paramBankBranch" AND 
		 "paramBankAccount" IS NULL AND "BankAccount" IS NULL OR "BankAccount" = "paramBankAccount" AND 
		 "paramBankAccountDigit" IS NULL AND "BankAccountDigit" IS NULL OR "BankAccountDigit" = "paramBankAccountDigit")
	AND
		("TaxId" = "paramTaxId")	
	AND 
		"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getfavored(bigint, character varying, character varying, character varying, character varying, character varying, integer)
    OWNER TO "OSB";
