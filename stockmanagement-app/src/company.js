import React from 'react';
import { List,DateField, Datagrid, TextField,EditButton,Edit,SimpleForm,Create,DateInput,TextInput } from 'react-admin';

export const CompanyList = (props) => (
    <List title="All companies" {...props}>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="name" />           
            <EditButton />
        </Datagrid>
    </List>
);

export const CompanyEdit = props => (
    <Edit {...props}>
        <SimpleForm>
        <TextField source="id" />
            <TextInput source="name" />
            
        </SimpleForm>
    </Edit>
);

export const CompanyCreate = props => (
    <Create {...props} redirect="show">
        <SimpleForm  >
         <TextInput source="name" />        
        </SimpleForm>
    </Create>
);