CREATE OR REPLACE FUNCTION public.updateuseraccount(
	"paramUserAccountId" bigint,
	"paramDeletionDate" timestamp without time zone
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."UserAccount"
			  SET	             
				 "DeletionDate" = "paramDeletionDate"
		 	  WHERE 
			  	  "DeletionDate" IS NULL AND
			  	  "UserAccountId" = "paramUserAccountId"
$BODY$;

ALTER FUNCTION public.updateuseraccount(bigint, timestamp without time zone)
    OWNER TO "OSB";
