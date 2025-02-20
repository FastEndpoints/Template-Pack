using Amazon.Runtime;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;
using Endpoint = Amazon.Runtime.Endpoints.Endpoint;

namespace MyProject.Tests;

class FakeSesClient : IAmazonSimpleEmailServiceV2
{
    public virtual Task<SendEmailResponse> SendEmailAsync(SendEmailRequest request, CancellationToken ct = default)
        => Task.FromResult(new SendEmailResponse());

#region unimplemented

    public IClientConfig Config => default!;
    public void Dispose() { }

    public Task<BatchGetMetricDataResponse> BatchGetMetricDataAsync(BatchGetMetricDataRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CancelExportJobResponse> CancelExportJobAsync(CancelExportJobRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateConfigurationSetResponse> CreateConfigurationSetAsync(CreateConfigurationSetRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateConfigurationSetEventDestinationResponse> CreateConfigurationSetEventDestinationAsync(CreateConfigurationSetEventDestinationRequest request,
                                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateContactResponse> CreateContactAsync(CreateContactRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateContactListResponse> CreateContactListAsync(CreateContactListRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateCustomVerificationEmailTemplateResponse> CreateCustomVerificationEmailTemplateAsync(CreateCustomVerificationEmailTemplateRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateDedicatedIpPoolResponse> CreateDedicatedIpPoolAsync(CreateDedicatedIpPoolRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateDeliverabilityTestReportResponse> CreateDeliverabilityTestReportAsync(CreateDeliverabilityTestReportRequest request,
                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateEmailIdentityResponse> CreateEmailIdentityAsync(CreateEmailIdentityRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateEmailIdentityPolicyResponse> CreateEmailIdentityPolicyAsync(CreateEmailIdentityPolicyRequest request,
                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateEmailTemplateResponse> CreateEmailTemplateAsync(CreateEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateExportJobResponse> CreateExportJobAsync(CreateExportJobRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateImportJobResponse> CreateImportJobAsync(CreateImportJobRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<CreateMultiRegionEndpointResponse> CreateMultiRegionEndpointAsync(CreateMultiRegionEndpointRequest request,
                                                                                  CancellationToken cancellationToken = new())
        => throw new NotImplementedException();

    public Task<DeleteConfigurationSetResponse> DeleteConfigurationSetAsync(DeleteConfigurationSetRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteConfigurationSetEventDestinationResponse> DeleteConfigurationSetEventDestinationAsync(DeleteConfigurationSetEventDestinationRequest request,
                                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteContactResponse> DeleteContactAsync(DeleteContactRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteContactListResponse> DeleteContactListAsync(DeleteContactListRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteCustomVerificationEmailTemplateResponse> DeleteCustomVerificationEmailTemplateAsync(DeleteCustomVerificationEmailTemplateRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteDedicatedIpPoolResponse> DeleteDedicatedIpPoolAsync(DeleteDedicatedIpPoolRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteEmailIdentityResponse> DeleteEmailIdentityAsync(DeleteEmailIdentityRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteEmailIdentityPolicyResponse> DeleteEmailIdentityPolicyAsync(DeleteEmailIdentityPolicyRequest request,
                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteEmailTemplateResponse> DeleteEmailTemplateAsync(DeleteEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<DeleteMultiRegionEndpointResponse> DeleteMultiRegionEndpointAsync(DeleteMultiRegionEndpointRequest request,
                                                                                  CancellationToken cancellationToken = new())
        => throw new NotImplementedException();

    public Task<DeleteSuppressedDestinationResponse> DeleteSuppressedDestinationAsync(DeleteSuppressedDestinationRequest request,
                                                                                      CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetAccountResponse> GetAccountAsync(GetAccountRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetBlacklistReportsResponse> GetBlacklistReportsAsync(GetBlacklistReportsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetConfigurationSetResponse> GetConfigurationSetAsync(GetConfigurationSetRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetConfigurationSetEventDestinationsResponse> GetConfigurationSetEventDestinationsAsync(GetConfigurationSetEventDestinationsRequest request,
                                                                                                        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetContactResponse> GetContactAsync(GetContactRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetContactListResponse> GetContactListAsync(GetContactListRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetCustomVerificationEmailTemplateResponse> GetCustomVerificationEmailTemplateAsync(GetCustomVerificationEmailTemplateRequest request,
                                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDedicatedIpResponse> GetDedicatedIpAsync(GetDedicatedIpRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDedicatedIpPoolResponse> GetDedicatedIpPoolAsync(GetDedicatedIpPoolRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDedicatedIpsResponse> GetDedicatedIpsAsync(GetDedicatedIpsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDeliverabilityDashboardOptionsResponse> GetDeliverabilityDashboardOptionsAsync(GetDeliverabilityDashboardOptionsRequest request,
                                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDeliverabilityTestReportResponse> GetDeliverabilityTestReportAsync(GetDeliverabilityTestReportRequest request,
                                                                                      CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDomainDeliverabilityCampaignResponse> GetDomainDeliverabilityCampaignAsync(GetDomainDeliverabilityCampaignRequest request,
                                                                                              CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetDomainStatisticsReportResponse> GetDomainStatisticsReportAsync(GetDomainStatisticsReportRequest request,
                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetEmailIdentityResponse> GetEmailIdentityAsync(GetEmailIdentityRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetEmailIdentityPoliciesResponse> GetEmailIdentityPoliciesAsync(GetEmailIdentityPoliciesRequest request,
                                                                                CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetEmailTemplateResponse> GetEmailTemplateAsync(GetEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetExportJobResponse> GetExportJobAsync(GetExportJobRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetImportJobResponse> GetImportJobAsync(GetImportJobRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetMessageInsightsResponse> GetMessageInsightsAsync(GetMessageInsightsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<GetMultiRegionEndpointResponse> GetMultiRegionEndpointAsync(GetMultiRegionEndpointRequest request, CancellationToken cancellationToken = new())
        => throw new NotImplementedException();

    public Task<GetSuppressedDestinationResponse> GetSuppressedDestinationAsync(GetSuppressedDestinationRequest request,
                                                                                CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListConfigurationSetsResponse> ListConfigurationSetsAsync(ListConfigurationSetsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListContactListsResponse> ListContactListsAsync(ListContactListsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListContactsResponse> ListContactsAsync(ListContactsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListCustomVerificationEmailTemplatesResponse> ListCustomVerificationEmailTemplatesAsync(ListCustomVerificationEmailTemplatesRequest request,
                                                                                                        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListDedicatedIpPoolsResponse> ListDedicatedIpPoolsAsync(ListDedicatedIpPoolsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListDeliverabilityTestReportsResponse> ListDeliverabilityTestReportsAsync(ListDeliverabilityTestReportsRequest request,
                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListDomainDeliverabilityCampaignsResponse> ListDomainDeliverabilityCampaignsAsync(ListDomainDeliverabilityCampaignsRequest request,
                                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListEmailIdentitiesResponse> ListEmailIdentitiesAsync(ListEmailIdentitiesRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListEmailTemplatesResponse> ListEmailTemplatesAsync(ListEmailTemplatesRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListExportJobsResponse> ListExportJobsAsync(ListExportJobsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListImportJobsResponse> ListImportJobsAsync(ListImportJobsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListMultiRegionEndpointsResponse> ListMultiRegionEndpointsAsync(ListMultiRegionEndpointsRequest request,
                                                                                CancellationToken cancellationToken =
                                                                                    default)
        => throw new NotImplementedException();

    public Task<ListRecommendationsResponse> ListRecommendationsAsync(ListRecommendationsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListSuppressedDestinationsResponse> ListSuppressedDestinationsAsync(ListSuppressedDestinationsRequest request,
                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<ListTagsForResourceResponse> ListTagsForResourceAsync(ListTagsForResourceRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutAccountDedicatedIpWarmupAttributesResponse> PutAccountDedicatedIpWarmupAttributesAsync(PutAccountDedicatedIpWarmupAttributesRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutAccountDetailsResponse> PutAccountDetailsAsync(PutAccountDetailsRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutAccountSendingAttributesResponse> PutAccountSendingAttributesAsync(PutAccountSendingAttributesRequest request,
                                                                                      CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutAccountSuppressionAttributesResponse> PutAccountSuppressionAttributesAsync(PutAccountSuppressionAttributesRequest request,
                                                                                              CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutAccountVdmAttributesResponse> PutAccountVdmAttributesAsync(PutAccountVdmAttributesRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetArchivingOptionsResponse> PutConfigurationSetArchivingOptionsAsync(
        PutConfigurationSetArchivingOptionsRequest request,
        CancellationToken cancellationToken = new())
        => throw new NotImplementedException();

    public Task<PutConfigurationSetDeliveryOptionsResponse> PutConfigurationSetDeliveryOptionsAsync(PutConfigurationSetDeliveryOptionsRequest request,
                                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetReputationOptionsResponse> PutConfigurationSetReputationOptionsAsync(PutConfigurationSetReputationOptionsRequest request,
                                                                                                        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetSendingOptionsResponse> PutConfigurationSetSendingOptionsAsync(PutConfigurationSetSendingOptionsRequest request,
                                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetSuppressionOptionsResponse> PutConfigurationSetSuppressionOptionsAsync(PutConfigurationSetSuppressionOptionsRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetTrackingOptionsResponse> PutConfigurationSetTrackingOptionsAsync(PutConfigurationSetTrackingOptionsRequest request,
                                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutConfigurationSetVdmOptionsResponse> PutConfigurationSetVdmOptionsAsync(PutConfigurationSetVdmOptionsRequest request,
                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutDedicatedIpInPoolResponse> PutDedicatedIpInPoolAsync(PutDedicatedIpInPoolRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutDedicatedIpPoolScalingAttributesResponse> PutDedicatedIpPoolScalingAttributesAsync(PutDedicatedIpPoolScalingAttributesRequest request,
                                                                                                      CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutDedicatedIpWarmupAttributesResponse> PutDedicatedIpWarmupAttributesAsync(PutDedicatedIpWarmupAttributesRequest request,
                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutDeliverabilityDashboardOptionResponse> PutDeliverabilityDashboardOptionAsync(PutDeliverabilityDashboardOptionRequest request,
                                                                                                CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutEmailIdentityConfigurationSetAttributesResponse> PutEmailIdentityConfigurationSetAttributesAsync(
        PutEmailIdentityConfigurationSetAttributesRequest request,
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutEmailIdentityDkimAttributesResponse> PutEmailIdentityDkimAttributesAsync(PutEmailIdentityDkimAttributesRequest request,
                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutEmailIdentityDkimSigningAttributesResponse> PutEmailIdentityDkimSigningAttributesAsync(PutEmailIdentityDkimSigningAttributesRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutEmailIdentityFeedbackAttributesResponse> PutEmailIdentityFeedbackAttributesAsync(PutEmailIdentityFeedbackAttributesRequest request,
                                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutEmailIdentityMailFromAttributesResponse> PutEmailIdentityMailFromAttributesAsync(PutEmailIdentityMailFromAttributesRequest request,
                                                                                                    CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<PutSuppressedDestinationResponse> PutSuppressedDestinationAsync(PutSuppressedDestinationRequest request,
                                                                                CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SendBulkEmailResponse> SendBulkEmailAsync(SendBulkEmailRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<SendCustomVerificationEmailResponse> SendCustomVerificationEmailAsync(SendCustomVerificationEmailRequest request,
                                                                                      CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<TagResourceResponse> TagResourceAsync(TagResourceRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<TestRenderEmailTemplateResponse> TestRenderEmailTemplateAsync(TestRenderEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UntagResourceResponse> UntagResourceAsync(UntagResourceRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateConfigurationSetEventDestinationResponse> UpdateConfigurationSetEventDestinationAsync(UpdateConfigurationSetEventDestinationRequest request,
                                                                                                            CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateContactResponse> UpdateContactAsync(UpdateContactRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateContactListResponse> UpdateContactListAsync(UpdateContactListRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateCustomVerificationEmailTemplateResponse> UpdateCustomVerificationEmailTemplateAsync(UpdateCustomVerificationEmailTemplateRequest request,
                                                                                                          CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateEmailIdentityPolicyResponse> UpdateEmailIdentityPolicyAsync(UpdateEmailIdentityPolicyRequest request,
                                                                                  CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Task<UpdateEmailTemplateResponse> UpdateEmailTemplateAsync(UpdateEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();

    public Endpoint DetermineServiceOperationEndpoint(AmazonWebServiceRequest request)
        => throw new NotImplementedException();

    public ISimpleEmailV2PaginatorFactory Paginators => default!;

#endregion
}