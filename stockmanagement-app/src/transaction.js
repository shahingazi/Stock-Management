import React from 'react';
import { List, Datagrid,SelectInput,SelectField , TextField,EditButton,Edit,SimpleForm,Create,DateInput,TextInput,NumberInput,ReferenceField,ReferenceInput } from 'react-admin';


const choices = [
    { id: 1, name: 'Buy' },
    { id: 2, name: 'Sell' },
 ];

export const TransactionList = (props) => (
    <List title="All Transactions" {...props}>
        <Datagrid rowClick="edit">
            
            <ReferenceField label="Product" source="productId" reference="product">
                <TextField source="name" />
            </ReferenceField>
            <SelectField  source="type" choices={choices} translateChoice={false}/>
            <TextField source="quantity" /> 
            <TextField source="amount" /> 
            <TextField source="createdAt" /> 
           
        </Datagrid>
    </List>
);


export const TransactionEdit = props => (
    <Edit {...props}>
        <SimpleForm>
        <TextField source="id" />
            <TextInput source="name" />
            <DateInput source="createdAt" />
        </SimpleForm>
    </Edit>
);


export const TransactionCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <SelectInput source="type" choices={choices} translateChoice={false}/>
            <NumberInput source="quantity" /> 
            <NumberInput source="amount" /> 
            <ReferenceInput label="Product" source="productId" reference="product">
                <SelectInput optionText="name" />
            </ReferenceInput>  
        <TextInput source="createdBy"/>

         <DateInput source="createdAt" />
        </SimpleForm>
    </Create>
);