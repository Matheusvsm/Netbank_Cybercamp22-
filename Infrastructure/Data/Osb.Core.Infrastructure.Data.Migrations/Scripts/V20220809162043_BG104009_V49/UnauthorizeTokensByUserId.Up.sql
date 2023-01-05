DROP FUNCTION public.unauthorizeauthorizationtokensbyuseridandaccountid(bigint, bigint);

CREATE FUNCTION public.unauthorizeauthorizationtokensbyuserid(
	"paramUserId" bigint)
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
        "Status" = 0
$BODY$;

ALTER FUNCTION public.unauthorizeauthorizationtokensbyuserid(bigint)
    OWNER TO "OSB";