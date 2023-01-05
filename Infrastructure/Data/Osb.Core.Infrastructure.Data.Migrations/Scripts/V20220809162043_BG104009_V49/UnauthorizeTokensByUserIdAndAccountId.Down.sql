DROP FUNCTION public.unauthorizeauthorizationtokensbyuserid(bigint);

CREATE FUNCTION public.unauthorizeauthorizationtokensbyuseridandaccountid(
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

ALTER FUNCTION public.unauthorizeauthorizationtokensbyuseridandaccountid(bigint, bigint)
    OWNER TO "OSB";