CREATE FUNCTION public.unauthorizeauthorizationtokensbytaxid(
	"paramTaxId" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."AuthorizationToken"
    
    SET 
        "Status" = 2

    WHERE
        "TaxId" = "paramTaxId" AND
        "Status" = 0
$BODY$;

ALTER FUNCTION public.unauthorizeauthorizationtokensbytaxid(character varying)
    OWNER TO "OSB";