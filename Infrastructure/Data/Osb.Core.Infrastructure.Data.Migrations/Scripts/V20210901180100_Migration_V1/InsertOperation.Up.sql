CREATE OR REPLACE FUNCTION public.insertoperation(    
    "paramUserId" bigint,
    "paramOperationType" integer    
)
    RETURNS TABLE("OperationId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Operation"(
     "OperationType",
     "CreationDate",
     "UpdateDate",
	 "CreationUserId",
	 "UpdateUserId"
    )
	VALUES (
        "paramOperationType",
         Now(),
         Now(), 
         "paramUserId",
         "paramUserId"
) RETURNING "OperationId";	
$BODY$;

ALTER FUNCTION public.insertoperation(bigint,integer)
    OWNER TO "OSB";