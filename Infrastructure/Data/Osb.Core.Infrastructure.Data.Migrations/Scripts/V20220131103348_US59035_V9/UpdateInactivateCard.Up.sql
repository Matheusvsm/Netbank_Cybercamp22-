DROP FUNCTION public.updateinactivatecard(bigint, integer, integer, bigint);

CREATE OR REPLACE FUNCTION public.updateinactivatecard(
	"paramInactivateCardId" bigint,
	"paramStatus" integer	
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."InactivateCard"
			  SET
                "Status" = "paramStatus",								
                "UpdateDate" = now()
		 	  WHERE 
	            "InactivateCardId" = "paramInactivateCardId"
$BODY$;

ALTER FUNCTION public.updateinactivatecard(bigint, integer)
    OWNER TO "OSB";
