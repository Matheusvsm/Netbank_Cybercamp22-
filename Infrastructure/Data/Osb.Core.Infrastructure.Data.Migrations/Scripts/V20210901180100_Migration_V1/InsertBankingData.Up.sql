CREATE OR REPLACE FUNCTION public.insertbankingdata(
	"paramBank" character varying,
	"paramBankBranch" character varying,
	"paramBankAccount" character varying,
	"paramBankAccountDigit" character varying,
    "paramUserId" bigint
    )    
    RETURNS TABLE("BankingDataId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
INSERT INTO public."BankingData"
    (
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
        "paramBank",
        "paramBankBranch",
        "paramBankAccount",
        "paramBankAccountDigit",
        now(),
        now(),
        "paramUserId",
        "paramUserId"
        )
         RETURNING "BankingDataId";
$BODY$;

ALTER FUNCTION public.insertbankingdata(character varying, character varying, character varying, character varying,bigint)
    OWNER TO "OSB";
