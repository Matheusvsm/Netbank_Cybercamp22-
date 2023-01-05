CREATE OR REPLACE FUNCTION public.getbankingdatabyid(
	"paramId" bigint)
    RETURNS TABLE("BankingDataId" bigint, "Bank" character varying, "BankBranch" character varying, "BankAccount" character varying, "BankAccountDigit" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  
	"BankingDataId",
	"Bank",
	"BankBranch",
	"BankAccount",
	"BankAccountDigit"
FROM
	public."BankingData" 
WHERE
	"BankingDataId" = "paramId"
	AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getbankingdatabyid(bigint)
    OWNER TO "OSB";
