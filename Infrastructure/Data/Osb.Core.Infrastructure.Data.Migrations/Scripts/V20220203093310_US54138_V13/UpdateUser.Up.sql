DROP FUNCTION public.updateuser(bigint, character varying, integer, integer);

CREATE OR REPLACE FUNCTION public.updateuser(
	"paramUserId" bigint,
	"paramLogin" character varying,
	"paramStatus" integer,
	"paramIsFirstAccess" boolean,
	"paramLoginAttempts" integer
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
				 "UpdateDate" = now()
		 	  WHERE 
			  	  "DeletionDate" IS NULL AND
			  	  "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuser(bigint, character varying, integer, boolean, integer)
    OWNER TO "OSB";
