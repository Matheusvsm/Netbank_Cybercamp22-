DROP FUNCTION public.updateactivatecard(bigint, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.updateactivatecard(
	"paramActivateCardId" bigint,
	"paramStatus" integer	
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."ActivateCard"
			  SET
                "Status" = "paramStatus",
                "UpdateDate" = now()				
		 	  WHERE 
	            "ActivateCardId" = "paramActivateCardId"
$BODY$;

ALTER FUNCTION public.updateactivatecard(bigint, integer)
    OWNER TO "OSB";
