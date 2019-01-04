import React from 'react';
import { List, Datagrid,ReferenceField, TextField ,EditButton,Edit,SimpleForm,SelectInput,Create, TextInput,DateInput,NumberInput,ReferenceInput  } from 'react-admin';


export const ProductList = (props) => (
    <List {...props}>
        <Datagrid>           
            <TextField source="name" />
            <ReferenceField label="Company" source="companyId" reference="company">
                <TextField source="name" />
            </ReferenceField>
            <EditButton />
        </Datagrid>
    </List>
);


export const ProductEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <TextField source="id" />
            <TextInput source="name" />
            <ReferenceInput label="Company" source="companyId" reference="company">
                <SelectInput optionText="name" />
            </ReferenceInput> 
         
        </SimpleForm>
    </Edit>
);

export const ProductCreate = props => (
    <Create {...props}>
        <SimpleForm>        
            <TextInput source="name" />            
            <ReferenceInput label="Company" source="companyId" reference="company">
                <SelectInput optionText="name" />
            </ReferenceInput>  
            <DateInput source="createdAt" />
            <TextInput source="createdBy" />
        </SimpleForm>
    </Create>
);