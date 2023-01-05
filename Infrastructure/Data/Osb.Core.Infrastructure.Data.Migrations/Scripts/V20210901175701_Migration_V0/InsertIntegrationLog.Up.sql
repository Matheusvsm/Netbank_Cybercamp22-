CREATE OR REPLACE FUNCTION public.insertintegrationlog(
	"paramBody" character varying,
	"paramHeaders" character varying,
	"paramUrl" character varying,
	"paramStatusCode" bigint,
	"paramResponse" character varying,
	"paramUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."IntegrationLog"(					
					"Body",
					"Headers",
					"Url",
					"StatusCode",
					"Response",    
					"CreationDate",					
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId"
					)
			VALUES (			    	
					"paramBody",
					"paramHeaders",
					"paramUrl",
					"paramStatusCode",
					"paramResponse",
					now(),
					now(),
					"paramUserId",
					"paramUserId"
					)
$BODY$;

ALTER FUNCTION public.insertintegrationlog(character varying, character varying, character varying, bigint, character varying, bigint)
    OWNER TO "OSB";