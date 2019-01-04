import React from 'react';
import { List, Datagrid, TextField,EditButton,Edit,SimpleForm,Create,DateInput,TextInput } from 'react-admin';

export const CompanyList = (props) => (
    <List title="All companies" {...props}>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="createdAt" />  
            <EditButton />
        </Datagrid>
    </List>
);


export const CompanyEdit = props => (
    <Edit {...props}>
        <SimpleForm>
        <TextField source="id" />
            <TextInput source="name" />
            <DateInput source="createdAt" />
        </SimpleForm>
    </Edit>
);


export const CompanyCreate = props => (
    <Create {...props}>
        <SimpleForm  >
         <TextInput source="name" />
         <DateInput source="createdAt" />
        </SimpleForm>
    </Create>
);