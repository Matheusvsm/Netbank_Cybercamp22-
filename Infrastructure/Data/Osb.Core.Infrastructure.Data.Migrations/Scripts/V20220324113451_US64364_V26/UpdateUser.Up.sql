DROP FUNCTION public.updateuser(bigint, character varying, integer, boolean, integer);

CREATE OR REPLACE FUNCTION public.updateuser(
	"paramUserId" bigint,
	"paramLogin" character varying,
	"paramStatus" integer,
	"paramIsFirstAccess" boolean,
	"paramLoginAttempts" integer,
	"paramDeletionDate" timestamp without time zone
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."User"
			  SET
	             "Login" = "paramLogin",			
				 "Status" = "paramStatus",
				 "IsFirstAccess" = "paramIsFirstAccess",
				 "LoginAttempts" = "paramLoginAttempts",
				 "UpdateDate" = now(),
				 "DeletionDate" = "paramDeletionDate"
		 	  WHERE 
			  	  "DeletionDate" IS NULL AND
			  	  "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuser(bigint, character varying, integer, boolean, integer, timestamp without time zone)
    OWNER TO "OSB";
