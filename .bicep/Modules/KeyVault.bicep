@description('Name of KeyVault')
param key_vault_name string

@description('Tennant ID')
param tennant_id string

@description('Tennant ID')
param workspace_id string

param location string = resourceGroup().location

resource vault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: '${key_vault_name}-${uniqueString(resourceGroup().id)}'
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: tennant_id
    enabledForDeployment: false
    enabledForDiskEncryption: false
    enabledForTemplateDeployment: false
    enableSoftDelete: true
    softDeleteRetentionInDays: 90
    enableRbacAuthorization: true
    provisioningState: 'Succeeded'
    publicNetworkAccess: 'Enabled'
  }
}


resource keyVaultSecretAccessRoleDef 'Microsoft.Authorization/roleDefinitions@2022-04-01' existing = {
  scope: vault
  name: '4633458b-17de-408a-b874-0445c86b69e6'
}


resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, workspace_id, keyVaultSecretAccessRoleDef.id)
  properties: {
    roleDefinitionId: keyVaultSecretAccessRoleDef.id
    principalId: workspace_id
    principalType: 'ServicePrincipal'
  }
}

