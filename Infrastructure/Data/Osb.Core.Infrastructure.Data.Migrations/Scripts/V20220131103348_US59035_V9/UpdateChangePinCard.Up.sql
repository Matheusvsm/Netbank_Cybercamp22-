DROP FUNCTION public.updatechangepincard(bigint, bigint, integer, integer);

CREATE OR REPLACE FUNCTION public.updatechangepincard(
	"paramChangePinCardId" bigint,		
	"paramStatus" integer	
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ChangePinCard"
		SET
		   "Status" = "paramStatus",		   
		   "UpdateDate" = Now()		   
		WHERE 
		   "DeletionDate" IS NULL 
		   AND "ChangePinCardId" = "paramChangePinCardId"
		   
$BODY$;

ALTER FUNCTION public.updatechangepincard(bigint, integer)
    OWNER TO "OSB";