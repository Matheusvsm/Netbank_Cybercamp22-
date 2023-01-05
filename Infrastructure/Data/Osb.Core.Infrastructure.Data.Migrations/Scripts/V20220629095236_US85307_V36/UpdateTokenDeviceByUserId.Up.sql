CREATE OR REPLACE FUNCTION public.updatedevicetokenbyuserid(
	"paramToken" character varying,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."Device"
              SET            
                "Token" = "paramToken"
              WHERE
                "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updatedevicetokenbyuserid(character varying, bigint)
    OWNER TO "OSB";
