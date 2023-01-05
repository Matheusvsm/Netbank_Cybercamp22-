CREATE OR REPLACE FUNCTION public.updatecancelcard(
	"paramCancelCardId" bigint,
	"paramStatus" integer
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."CancelCard"
			  SET
                "Status" = "paramStatus",
                "UpdateDate" = now()
		 	  WHERE 
	            "CancelCardId" = "paramCancelCardId"
                AND "DeletionDate" = null
$BODY$;

ALTER FUNCTION public.updatecancelcard(bigint, integer)
    OWNER TO "OSB";
