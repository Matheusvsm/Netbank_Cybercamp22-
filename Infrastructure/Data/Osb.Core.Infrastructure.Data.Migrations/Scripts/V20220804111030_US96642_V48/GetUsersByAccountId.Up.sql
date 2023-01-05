CREATE OR REPLACE FUNCTION public.getusersbyaccountid(
"paramAccountId" bigint)

RETURNS TABLE("AccountId" bigint, "UserId" bigint, "CreationUserId" bigint, "UpdateUserId" bigint)
LANGUAGE 'sql'
COST 100
VOLATILE PARALLEL UNSAFE
ROWS 1000

AS $BODY$

SELECT "AccountId",
       "UserId",
       "CreationUserId",
       "UpdateUserId"
    
FROM public."UserAccount"
    
WHERE "AccountId" = "paramAccountId" 
    
    AND "DeletionDate" IS NULL

$BODY$;

ALTER FUNCTION public.getusersbyaccountid(bigint)
    OWNER TO "OSB";