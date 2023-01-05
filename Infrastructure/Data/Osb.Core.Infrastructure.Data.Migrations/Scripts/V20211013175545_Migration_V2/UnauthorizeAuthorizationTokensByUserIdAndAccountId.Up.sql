CREATE OR REPLACE FUNCTION public.unauthorizeauthorizationtokensbyuseridandaccountId(	
    "paramUserId" bigint,
    "paramAccountId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

UPDATE public."AuthorizationToken"
    
    SET 
        "Status" = 2

    WHERE
        "UserId" = "paramUserId" AND
        "AccountId" = "paramAccountId" AND
        "Status" = 0
$BODY$;

ALTER FUNCTION public.unauthorizeauthorizationtokensbyuseridandaccountId(bigint, bigint)
    OWNER TO "OSB";