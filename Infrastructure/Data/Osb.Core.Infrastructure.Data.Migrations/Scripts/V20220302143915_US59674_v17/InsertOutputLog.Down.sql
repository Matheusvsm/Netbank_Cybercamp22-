DROP FUNCTION public.insertoutputlog(character varying, character varying, bigint);

CREATE OR REPLACE FUNCTION public.insertoutputlog(
	"paramResponse" character varying,
	"paramUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."OutputLog" 
		(
		"Response",		
		"LogDate",
		"CreationDate",
		"UpdateDate",
		"CreationUserId",
		"UpdateUserId"
		)
	VALUES (        		 
		"paramResponse",
		now(),
		now(),
		now(),
		"paramUserId",
		"paramUserId"
		)
$BODY$;

ALTER FUNCTION public.insertoutputlog(character varying, bigint)
    OWNER TO "OSB";
