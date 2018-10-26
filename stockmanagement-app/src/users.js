import React from 'react';
import { List, Datagrid, EmailField, TextField,EditButton,Edit,SimpleForm,DisabledInput,Create,TextInput } from 'react-admin';

export const UsersList = (props) => (
    <List title="All users" {...props}>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="firstName" />
            <TextField source="lastName" />
            <EmailField source="email" />
            <EditButton />
        </Datagrid>
    </List>
);


export const UserEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <TextInput source="id" />
            <TextInput source="firstName" />
            <TextInput source="lastName" />
            <TextInput source="email" />
            <TextInput source="password" type="password" />
        </SimpleForm>
    </Edit>
);


export const UserCreate = props => (
    <Create {...props}>
        <SimpleForm>
        <TextInput source="firstName" />
            <TextInput source="lastName" />
            <TextInput source="email" />
            <TextInput source="password" type="password" />
        </SimpleForm>
    </Create>
);