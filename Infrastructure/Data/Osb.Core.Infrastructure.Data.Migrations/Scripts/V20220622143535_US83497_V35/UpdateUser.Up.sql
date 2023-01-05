DROP FUNCTION public.updateuser(bigint, character varying, integer, boolean, integer, timestamp without time zone);

CREATE FUNCTION public.updateuser(
	"paramUserId" bigint,
	"paramLogin" character varying,
	"paramStatus" integer,
	"paramIsFirstAccess" boolean,
	"paramLoginAttempts" integer,
	"paramDeletionDate" timestamp without time zone,
	"paramAcceptedTerms" boolean
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
				 "DeletionDate" = "paramDeletionDate",
				 "AcceptedTerms" = "paramAcceptedTerms"
		 	  WHERE 
			  	  "DeletionDate" IS NULL AND
			  	  "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuser(bigint, character varying, integer, boolean, integer, timestamp without time zone, boolean)
    OWNER TO "OSB";
