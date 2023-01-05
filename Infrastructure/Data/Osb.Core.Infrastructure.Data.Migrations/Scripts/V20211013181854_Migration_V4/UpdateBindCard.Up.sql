CREATE OR REPLACE FUNCTION public.updatebindcard(
	"paramBindCardId" bigint,
	"paramStatus" integer,
	"paramAttempts" integer,
	"paramUsageType" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."BindCard"
			  SET
                "Status" = "paramStatus",
				"UsageType" = "paramUsageType",
                "Attempts" = "paramAttempts",
                "UpdateDate" = now()
		 	  WHERE 
	            "BindCardId" = "paramBindCardId"
$BODY$;

ALTER FUNCTION public.updatebindcard(bigint, integer, integer, integer)
    OWNER TO "OSB";