DROP FUNCTION IF EXISTS public.getfavoredbyaccountid(bigint);

CREATE OR REPLACE FUNCTION public.getfavoredbyaccountidandoperationtype(
    "paramAccountId" bigint,
    "paramOperationType" bigint)
    
    RETURNS TABLE("FavoredId" bigint, 
    "AccountId" bigint, 
    "TaxId" character varying, 
    "Name" character varying, 
    "OperationType" smallint, 
    "BankName" character varying, 
    "Bank" character varying, 
    "BankBranch" character varying, 
    "BankAccount" character varying, 
    "BankAccountDigit" character varying, 
    "CreationDate" timestamp with time zone, 
    "UpdateDate" timestamp with time zone, 
    "DeletionDate" timestamp with time zone, 
    "CreationUserId" bigint, 
    "UpdateUserId" bigint) 
    
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
       "BankName",
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
        "Favored"
    WHERE
        "AccountId" = "paramAccountId" AND
        "OperationType" = "paramOperationType"
    AND
        "DeletionDate" IS NULL

    ORDER BY "UpdateDate" DESC LIMIT 5;

$BODY$;
ALTER FUNCTION public.getfavoredbyaccountidandoperationtype(bigint,bigint)
    OWNER TO "OSB";