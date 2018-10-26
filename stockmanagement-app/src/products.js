import React from 'react';
import { List, Datagrid, TextField ,EditButton,Edit,SimpleForm,DisabledInput,Create, TextInput,DateInput,NumberInput } from 'react-admin';


export const ProductList = (props) => (
    <List {...props}>
        <Datagrid>           
            <TextField source="name" />
            <TextField source="barCode" />
            <TextField source="quantity" />
            <EditButton />
        </Datagrid>
    </List>
);


export const ProductEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <DisabledInput source="id" />
            <TextInput source="name" />
            <TextInput source="barCode" />
            <NumberInput source="quantity" />
            <DateInput source="createdAt" />
            <TextInput source="createdBy" />
        </SimpleForm>
    </Edit>
);

export const ProductCreate = props => (
    <Create {...props}>
        <SimpleForm>        
            <TextInput source="name" />
            <TextInput source="barCode" />
            <NumberInput source="quantity" />
            <DateInput source="createdAt" />
            <TextInput source="createdBy" />
        </SimpleForm>
    </Create>
);