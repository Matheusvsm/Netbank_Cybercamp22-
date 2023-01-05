CREATE OR REPLACE FUNCTION public.insertoperationattachment(
	"paramOperationId" bigint,
	"paramName" character varying,
	"paramExtension" character varying,
	"paramUserId" bigint)
    RETURNS void 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE

AS $BODY$
INSERT INTO public."OperationAttachment"(
	"OperationId",
	"Name",
	"Extension",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId",
	"UpdateUserId")
	VALUES
	("paramOperationId",
	 "paramName",
	 "paramExtension",
	 now(),
	 now(),
	 NULL,
	 "paramUserId",
	 "paramUserId")
$BODY$;

ALTER FUNCTION public.insertoperationattachment(bigint, character varying, character varying, bigint)
    OWNER TO "OSB";