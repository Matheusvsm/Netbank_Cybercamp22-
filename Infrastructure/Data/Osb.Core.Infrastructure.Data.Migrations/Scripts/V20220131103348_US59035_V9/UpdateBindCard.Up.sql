DROP FUNCTION public.updatebindcard(bigint, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.updatebindcard(
	"paramBindCardId" bigint,
	"paramStatus" integer
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BindCard"
			  SET
                "Status" = "paramStatus",
                "UpdateDate" = now()
		 	  WHERE 
	            "BindCardId" = "paramBindCardId"
$BODY$;

ALTER FUNCTION public.updatebindcard(bigint, integer)
    OWNER TO "OSB";